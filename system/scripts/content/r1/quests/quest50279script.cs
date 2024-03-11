//--- Melia Script -----------------------------------------------------------
// Deciphering the Mysterious Writings (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Barte.
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

[QuestScript(50279)]
public class Quest50279Script : QuestScript
{
	protected override void Load()
	{
		SetId(50279);
		SetName("Deciphering the Mysterious Writings (1)");
		SetDescription("Talk to Barte");

		AddPrerequisite(new LevelPrerequisite(151));

		AddDialogHook("PILGRIM_36_2_BARTE", "BeforeStart", BeforeStart);
		AddDialogHook("SAGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD362_HQ1_start1", "PILGRIMROAD362_HQ1", "Let me show you the copy so you can read it.", "It's nothing, really."))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD362_HQ1_agree1");
				await dialog.Msg("BalloonText/PILGRIMROAD362_HQ1_INFOR1/5");
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

		await dialog.Msg("PILGRIMROAD362_HQ1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIMROAD362_HQ2");
	}
}

