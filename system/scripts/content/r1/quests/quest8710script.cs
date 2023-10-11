//--- Melia Script -----------------------------------------------------------
// Wall of Sword and Shield [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Look for the Rodelero Submaster .
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

[QuestScript(8710)]
public class Quest8710Script : QuestScript
{
	protected override void Load()
	{
		SetId(8710);
		SetName("Wall of Sword and Shield [Rodelero Advancement]");
		SetDescription("Look for the Rodelero Submaster ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_RODELERO4_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Rodelero Submaster", new KillObjective(1, MonsterId.Npc_ROD_Sub_Master_Mon));

		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RODELERO4_1_01", "JOB_RODELERO4_1", "Accept the duel with the Master", "Avoid the duel"))
		{
			case 1:
				await dialog.Msg("JOB_RODELERO4_1_02");
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

		await dialog.Msg("JOB_RODELERO4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

