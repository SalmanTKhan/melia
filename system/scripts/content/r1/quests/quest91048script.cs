//--- Melia Script -----------------------------------------------------------
// Forces Who Occupied the Paupys Crossing (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Lada.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(91048)]
public class Quest91048Script : QuestScript
{
	protected override void Load()
	{
		SetId(91048);
		SetName("Forces Who Occupied the Paupys Crossing (2)");
		SetDescription("Talk to Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_01"));

		AddObjective("collect0", "Collect 10 Token of Demon King Baiga(s)", new CollectItemObjective("EP13_F_SIAULIAI_3_MQ_02_ITEM_01", 10));
		AddDrop("EP13_F_SIAULIAI_3_MQ_02_ITEM_01", 5f, "biblioteka_keeper");

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28148));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_02_DLG1", "EP13_F_SIAULIAI_3_MQ_02", "I'll defeat the demons who attacked the Orsha", "I have to rush to other place right now"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_3_MQ_02_DLG2");
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP13_F_SIAULIAI_3_MQ_LADA_1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_3_MQ_03");
	}
}

