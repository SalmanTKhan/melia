//--- Melia Script -----------------------------------------------------------
// Adventurer's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adventurer Varkis.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(1058)]
public class Quest1058Script : QuestScript
{
	protected override void Load()
	{
		SetId(1058);
		SetName("Adventurer's Favor (1)");
		SetDescription("Talk to Adventurer Varkis");

		AddPrerequisite(new LevelPrerequisite(73));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("VACYS_LIVE", "BeforeStart", BeforeStart);
		AddDialogHook("VACYS_LIVE_ENTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_VACYS1_select1", "ROKAS29_VACYS1", "I can find it", "Decline"))
		{
			case 1:
				await dialog.Msg("ROKAS29_VACYS1_prog1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS29_VACYS2");
	}
}

