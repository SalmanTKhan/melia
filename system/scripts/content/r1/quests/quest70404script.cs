//--- Melia Script -----------------------------------------------------------
// Destroy the Magic Power Supply Device
//--- Description -----------------------------------------------------------
// Quest to Talk to Mage Melchioras.
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

[QuestScript(70404)]
public class Quest70404Script : QuestScript
{
	protected override void Load()
	{
		SetId(70404);
		SetName("Destroy the Magic Power Supply Device");
		SetDescription("Talk to Mage Melchioras");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "CASTLE65_1_MQ05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_1_MQ04"));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 12996));

		AddDialogHook("CASTLE651_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_MQ_05_start", "CASTLE65_1_MQ05", "I'll set down the orbs", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("CASTLE651_MQ_05_agree");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Go to the Magic Power Supply Device in Ishinti Crossroads ", 5);
				dialog.HideNPC("CASTLE651_MQ_05_1_O");
				dialog.HideNPC("CASTLE651_MQ_05_2_O");
				dialog.HideNPC("CASTLE651_MQ_05_3_O");
				dialog.HideNPC("CASTLE651_MQ_05");
				dialog.UnHideNPC("CASTLE651_MQ_05_PILLAR_B");
				dialog.UnHideNPC("CASTLE651_MQ_03");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
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
}

