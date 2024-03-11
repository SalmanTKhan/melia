//--- Melia Script -----------------------------------------------------------
// Curiosity at the End of the Cliff
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Deltlan.
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

[QuestScript(60159)]
public class Quest60159Script : QuestScript
{
	protected override void Load()
	{
		SetId(60159);
		SetName("Curiosity at the End of the Cliff");
		SetDescription("Talk to Epigraphist Deltlan");

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 13 Wendigo(s) or Dumaro(s) or Wendigo Archer(s) or Wendigo Magician(s)", new KillObjective(13, 41446, 57038, 57621, 57619));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS24_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_RP_1_1", "ROKAS26_RP_1", "Alright, I'll help you", "I don't think I can help you."))
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

		await dialog.Msg("ROKAS26_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

