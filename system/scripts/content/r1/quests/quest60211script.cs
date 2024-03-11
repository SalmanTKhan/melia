//--- Melia Script -----------------------------------------------------------
// Alembique Tales(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Heranda.
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

[QuestScript(60211)]
public class Quest60211Script : QuestScript
{
	protected override void Load()
	{
		SetId(60211);
		SetName("Alembique Tales(2)");
		SetDescription("Talk to Mercenary Heranda");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_1"));

		AddObjective("kill0", "Kill 16 Green Charog(s) or Green Charcoal Walker(s) or Green Blindlem(s) or Cave Ravinelarva(s)", new KillObjective(16, 58477, 58478, 58479, 58570));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_HELANDA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_HELANDA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQ_2_1", "LSCAVE551_SQ_2", "I will help you. Just calm down.", "Ignore"))
		{
			case 1:
				await dialog.Msg("LSCAVE551_SQ_2_2");
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

		await dialog.Msg("LSCAVE551_SQ_2_3");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "No more talk can be done with Heranda, it seems.{nl}Find other people heading Engoa Stalactite Cave.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

