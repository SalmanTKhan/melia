//--- Melia Script -----------------------------------------------------------
// Officer Liudas' Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to Officer Luders.
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

[QuestScript(9109)]
public class Quest9109Script : QuestScript
{
	protected override void Load()
	{
		SetId(9109);
		SetName("Officer Liudas' Favor");
		SetDescription("Talk to Officer Luders");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 30 Woodsman(s) or Siaulamb Lagoon(s) or Siaulamb Shaman(s) or Siaulamb Warrior(s)", new KillObjective(30, 400761, 57203, 57202, 57205));

		AddDialogHook("SIAULIAI_16_VACENIN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_16_VACENIN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_16_HQ_01_select01", "SIAULIAI_16_HQ_01", "I'll do it", "Refuse"))
		{
			case 1:
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

		await dialog.Msg("SIAULIAI_16_HQ_01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

