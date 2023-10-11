//--- Melia Script -----------------------------------------------------------
// Deciphering the Mysterious Writings (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sage Master.
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

[QuestScript(50280)]
public class Quest50280Script : QuestScript
{
	protected override void Load()
	{
		SetId(50280);
		SetName("Deciphering the Mysterious Writings (2)");
		SetDescription("Talk with the Sage Master");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD362_HQ1"));

		AddDialogHook("SAGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD362_HQ2_start1", "PILGRIMROAD362_HQ2", "Do you have anything in mind?", "I have other issues to tend to, sorry."))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD362_HQ2_agree1");
				await dialog.Msg("BalloonText/PILGRIMROAD362_HIDDENQ2_infor1/3");
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

		await dialog.Msg("PILGRIMROAD362_HQ2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIMROAD362_HQ3");
	}
}

