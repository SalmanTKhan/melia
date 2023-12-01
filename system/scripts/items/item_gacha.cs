using System;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;
using Melia.Zone.World.Actors.Monsters;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.World.Actors.CombatEntities.Components;
using System.Collections.Generic;

public class ItemGachaScripts : GeneralScript
{
	/// <summary>
	/// Unlocks an achievement by adding 1 achievement point specified by the item.
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction("SCR_USE_GHACHA_TPCUBE")]
	public ItemUseResult SCR_USE_GHACHA_TPCUBE(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		if (character.IsRiding || character.Buffs.Has(BuffId.SwellLeftArm_Buff) || character.Buffs.Has(BuffId.SwellRightArm_Buff))
		{
			character.SystemMessage("DonUseItemOnRIde");
			return ItemUseResult.Fail;
		}

		//ZoneServer.Instance.Data.GachaDb

		return ItemUseResult.Okay;
	}

	/**
	public void SCR_ITEM_GACHA(Character character, string group, int cubeID, int btnVisible, bool bEnableDuplicate, int reopenCount = -1)
	{
		var rewardID = "reward_freedungeon";

		if (cubeID == 642501)
			rewardID = "reward_tp";

		var rewardList = new List<string>();
		var rewardCnt = new List<int>();
		var ratioList = new List<int>();
		var rewardGroupName = new List<string>();
		var listIndex = 0;
		var totalRatio = 0; // 처음에는 비용이 0이다.
		var clslist = GetClassList(rewardID);
		var cnt = clslist.Count;
		var totalPrice = 0;

		string rewGroup = null;
		var cubeItem = GetClassByType("Item", cubeID);
		if (group != null) // 무료 뽑기	
			rewGroup = group;
		else // 유료 뽑기 (Group이 null이다.)
		{
			rewGroup = TryGetProp(cubeItem, "StringArg"); // 보상그룹 알아내기
			totalPrice = TryGetProp(cubeItem, "NumberArg1"); // 비용 알아내기		
		}

		if (rewGroup == null)
		{
			CLEAR_GACHA_COMMAND(character, group);
			return;
		}

		if (IS_SEASON_SERVER(character) == "YES")
		{
			totalPrice = (int)Math.Floor(totalPrice / 2);
		}

		if (reopenCount == 1)
		{

			float discountRatio = TryGetProp(cubeItem, "ReopenDiscountRatio");
			if (discountRatio != null && discountRatio > 0)
			{
				discountRatio = 1 - (discountRatio / 100);
			}
			else
			{
				discountRatio = 1;
			}

			totalPrice = SyncFloor(totalPrice * discountRatio);

		}

		if (CHECK_PC_MONEY_FOR_PAY(character, totalPrice) == 0)
		{
			CLEAR_GACHA_COMMAND(character, group);
			return;
		}

		for (int i = 0; i <= cnt; i++) // 보상리스트에서 확률로 보상 계산
		{
			var rewardcls = GetClassByIndexFromList(clslist, i);
			if (TryGetProp(rewardcls, "Group") == rewGroup && CHECK_GACHA_DUPLICATE(character, bEnableDuplicate, rewardcls.ItemName) == true)
			{
				rewardList.Add(rewardcls.ItemName);
				var cls = GetClass("Item", rewardcls.ItemName);
				if (cls != null)
				{
					rewardGroupName.Add(cls.GroupName);
				}
				else
				{
					rewardGroupName.Add("None");
				}
				rewardCnt.Add(rewardcls.Count);
				ratioList.Add(rewardcls.Ratio);
				listIndex++;
				totalRatio += rewardcls.Ratio; // 전체 확률
			}
		}

		// get reward
		if (listIndex <= 0)
		{
			CLEAR_GACHA_COMMAND(character, group);
			return;
		}
		string reward = null;
		int rewardCount;
		string rewardGroup;
		double checkTime = imcTime.GetAppTime() + 1;
		while (reward == null)
		{
			if (checkTime < imcTime.GetAppTime())
			{
				CLEAR_GACHA_COMMAND(character, group);
				return;
			}
			reward = null;
			int result = IMCRandom(1, totalRatio); // 보상 뽑기용 랜덤수
			result = result * JAEDDURY_DROP_ITEM_RATE;
			for (int i = 0; i < ratioList.Count; i++)
			{
				if (result <= ratioList[i])
				{
					reward = rewardList[i];
					rewardCount = rewardCnt[i];
					rewardGroup = rewardGroupName[i];
					break;
				}
				else
				{
					ratioList[i + 1] = ratioList[i + 1] + ratioList[i];
				}
			}

			if (reward != null)
			{
				break;
			}
		}

		// give reward
		if (reward != null)
		{
			//Tx 구간
			var tx = TxBegin(character);
			TxEnableInIntegrateIndun(tx);

			if (totalPrice > 0)
			{
				TxTakeItem(tx, MONEY_NAME, totalPrice, "GACHA_CUBE", 0, cubeID);
			}
			TxGiveItem(tx, reward, rewardCount, "GACHA_CUBE");
			var ret = TxCommit(tx);
			//Tx 구간 끝

			if (ret == "SUCCESS")
			{
				if (group != null)
				{
					if (TryGetProp(cubeItem, "AllowReopen") == "NO")
					{
						ClearGachaCmd(character);
						btnVisible = 0;
					}
					string sucScp = "";
					sucScp = string.Format("GACHA_CUBE_SUCEECD(\'{0}\', \'{1}\', {2},{3})", cubeID, reward, btnVisible, reopenCount);
					ExecClientScp(character, sucScp); //성공여부를 클라이언트에 알린다.	(창 만들기)

				}
				else
				{
					string sucScp = "";
					sucScp = string.Format("GACHA_CUBE_SUCEECD_EX(\'{0}\', \'{1}\', {2},{3})", cubeID, reward, btnVisible, reopenCount);
					ExecClientScp(character, sucScp); //성공여부를 클라이언트에 알린다.	(창 요소만 바꾸기)							
					UpdateCubeCmd(character, reward); // 큐브의 뽑기 횟수를 업데이트하기 위한 함수
				}

				// update reward list
				if (bEnableDuplicate == false)
				{
					UpdateCubeReward(character, reward);
				}
			}
		}
	}
	**/
}
