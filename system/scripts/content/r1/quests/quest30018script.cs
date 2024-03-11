//--- Melia Script -----------------------------------------------------------
// Passing Words (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Vita.
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

[QuestScript(30018)]
public class Quest30018Script : QuestScript
{
	protected override void Load()
	{
		SetId(30018);
		SetName("Passing Words (2)");
		SetDescription("Talk with Kupole Vita");

		AddPrerequisite(new LevelPrerequisite(194));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_1_SQ_01"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6014));

		AddDialogHook("CATACOMB_38_1_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_1_OBJ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_1_SQ_02_select", "CATACOMB_38_1_SQ_02", "I've talked with the wandering spirit", "Leave now"))
		{
			case 1:
				await dialog.Msg("CATACOMB_38_1_SQ_02_agree");
				dialog.UnHideNPC("CATACOMB_38_1_GHOST_01");
				dialog.UnHideNPC("CATACOMB_38_1_GHOST_02");
				dialog.UnHideNPC("CATACOMB_38_1_GHOST_03");
				dialog.UnHideNPC("CATACOMB_38_1_GHOST_04");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "You sense ominous energy from the pot!{nl}Return to Kupole Vita and inform her about the situation", 5);
		await dialog.Msg("CameraShockWaveLocal/2/99999/10/2/200/0");
		ZoneServer.Instance.World.FindNPC("CATACOMB_38_1_OBJ_01")?.PlayEffectLocal(character.Connection, "F_wizard_attackground_shot_smoke", 1f, "BOT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

