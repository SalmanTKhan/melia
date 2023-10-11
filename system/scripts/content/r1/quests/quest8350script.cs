//--- Melia Script -----------------------------------------------------------
// Learning Skills
//--- Description -----------------------------------------------------------
// Quest to Talk to the Search Scout.
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

[QuestScript(8350)]
public class Quest8350Script : QuestScript
{
	protected override void Load()
	{
		SetId(8350);
		SetName("Learning Skills");
		SetDescription("Talk to the Search Scout");

		AddPrerequisite(new LevelPrerequisite(3));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_MEET_NAGLIS"));

		AddDialogHook("SIAUL_WEST_NAGLIS2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_NAGLIS2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TUTO_SKILL_RUN_01", "TUTO_SKILL_RUN", "I'd like to learn some skills", "Give me some time to think about it"))
		{
			case 1:
				dialog.ShowHelp("TUTO_SKILL;Tuto");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You can check your skills by pressing the F3 key");
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

		await dialog.Msg("TUTO_SKILL_RUN_03");
		dialog.ShowHelp("TUTO_TECH");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_WEST_SOLDIER3");
	}
}

