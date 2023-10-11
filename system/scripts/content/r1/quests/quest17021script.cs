//--- Melia Script -----------------------------------------------------------
// Now It's Really Suspicious
//--- Description -----------------------------------------------------------
// Quest to Find the Sealed Stone.
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

[QuestScript(17021)]
public class Quest17021Script : QuestScript
{
	protected override void Load()
	{
		SetId(17021);
		SetName("Now It's Really Suspicious");
		SetDescription("Find the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(123));

		AddObjective("kill0", "Kill 5 Black Desmodus(s) or Wizard Shaman Doll(s) or Flask(s) or Minivern(s)", new KillObjective(5, 57220, 47401, 47396, 57050));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER44_SQ_05_ST", "FTOWER44_SQ_05", "I'll defeat it", "Ignore"))
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

		await dialog.Msg("FTOWER44_SQ_05_COMP");
		await dialog.Msg("NPCChat/FTOWER44_SQ_05/자유롭게 해 줘서 고맙다.");
		ZoneServer.Instance.World.FindNPC("FTOWER44_SQ_05")?.PlayEffectLocal(character.Connection, "F_archer_scarecrow_shot_smoke", 2f, "BOT");
		dialog.HideNPC("FTOWER44_SQ_05");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

