//--- Melia Script -----------------------------------------------------------
// Rescue the Villagers
//--- Description -----------------------------------------------------------
// Quest to Talk to Vaidotas.
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

[QuestScript(1045)]
public class Quest1045Script : QuestScript
{
	protected override void Load()
	{
		SetId(1045);
		SetName("Rescue the Villagers");
		SetDescription("Talk to Vaidotas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MINE_3_RESQUE1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(21));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_ALCHEMIST"));
		AddPrerequisite(new ItemPrerequisite("CMINE_COMPASS_ITEM", -100));

		AddObjective("kill0", "Kill 7 Crystal Spider(s)", new KillObjective(7, MonsterId.Quartz_Weaver));

		AddReward(new ExpReward(53720, 53720));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("MINE_3_ALCHEMIST", "BeforeStart", BeforeStart);
		AddDialogHook("MINE_3_RESIENT1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MINE_3_RESQUE1_dlg1", "MINE_3_RESQUE1", "Rescue the villagers and then search for the Light of Salvation", "Quit"))
		{
			case 1:
				dialog.UnHideNPC("MINE_3_RESIENT1_BIND");
				dialog.UnHideNPC("MINE_3_GIRL_BIND");
				dialog.UnHideNPC("D_CMINE_NPC01_BIND");
				dialog.UnHideNPC("D_CMINE_NPC02_BIND");
				await dialog.Msg("MINE_3_RESQUE1_R");
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

		await dialog.Msg("MINE_3_RESQUE1_succ");
		dialog.HideNPC("MINE_3_ALCHEMIST");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

