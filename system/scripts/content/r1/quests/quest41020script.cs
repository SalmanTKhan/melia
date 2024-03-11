//--- Melia Script -----------------------------------------------------------
// The Story of Albinas
//--- Description -----------------------------------------------------------
// Quest to Talk to Albinas.
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

[QuestScript(41020)]
public class Quest41020Script : QuestScript
{
	protected override void Load()
	{
		SetId(41020);
		SetName("The Story of Albinas");
		SetDescription("Talk to Albinas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_010"));

		AddDialogHook("PILGRIM_36_2_ALBINAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_SQ_020_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_020_ST", "PILGRIM_36_2_SQ_020", "I will help", "I am not interested in it"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_020_AC");
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

		dialog.HideNPC("PILGRIM_36_2_SHRINE_FK");
		dialog.HideNPC("PILGRIM_36_2_ALBINAS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

