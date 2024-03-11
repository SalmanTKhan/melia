//--- Melia Script -----------------------------------------------------------
// Private matter
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(50040)]
public class Quest50040Script : QuestScript
{
	protected override void Load()
	{
		SetId(50040);
		SetName("Private matter");
		SetDescription("Talk to the Cryomancer Master");

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_070_startnpc01", "PARTY_Q_070", "I will help the experiment", "I don't have time for it"))
		{
			case 1:
				dialog.UnHideNPC("PARTY_Q7_DEVICE");
				dialog.UnHideNPC("PARTY_Q7_DEVICE02");
				await dialog.Msg("PARTY_Q_070_startnpc02");
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

		await dialog.Msg("PARTY_Q_070_succ01");
		dialog.HideNPC("PARTY_Q7_DEVICE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

