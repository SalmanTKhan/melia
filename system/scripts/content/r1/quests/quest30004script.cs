//--- Melia Script -----------------------------------------------------------
// Disciple Hones' Circumstances
//--- Description -----------------------------------------------------------
// Quest to Talk with Disciple Hones.
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

[QuestScript(30004)]
public class Quest30004Script : QuestScript
{
	protected override void Load()
	{
		SetId(30004);
		SetName("Disciple Hones' Circumstances");
		SetDescription("Talk with Disciple Hones");

		AddPrerequisite(new LevelPrerequisite(188));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_03"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5828));

		AddDialogHook("CATACOMB_38_2_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_2_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_2_SQ_04_start", "CATACOMB_38_2_SQ_04", "Ask him what he meant", "Quit"))
		{
			case 1:
				await dialog.Msg("CATACOMB_38_2_SQ_04_agree");
				dialog.UnHideNPC("CATACOMB_38_2_DIARY_01");
				dialog.UnHideNPC("CATACOMB_38_2_DIARY_02");
				dialog.UnHideNPC("CATACOMB_38_2_DIARY_03");
				dialog.UnHideNPC("CATACOMB_38_2_DIARY_04");
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

		await dialog.Msg("CATACOMB_38_2_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_2_SQ_05");
	}
}

