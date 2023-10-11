//--- Melia Script -----------------------------------------------------------
// Suspicious Voice
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17007)]
public class Quest17007Script : QuestScript
{
	protected override void Load()
	{
		SetId(17007);
		SetName("Suspicious Voice");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(116));

		AddObjective("kill0", "Kill 5 Blindlem(s)", new KillObjective(5, MonsterId.Blindlem));
		AddObjective("kill1", "Kill 5 Belegg(s)", new KillObjective(5, MonsterId.Belegg));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER42_SQ_01_ST", "FTOWER42_SQ_01", "Defeat it", "It's strange so just ignore it"))
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

		await dialog.Msg("FTOWER42_SQ_01_COMP");
		await dialog.Msg("NPCChat/FTOWER42_SQ_01/이제 자유로와 질 수 있어..");
		ZoneServer.Instance.World.FindNPC("FTOWER42_SQ_01")?.PlayEffectLocal(character.Connection, "F_archer_scarecrow_shot_smoke", 2f, "BOT");
		dialog.HideNPC("FTOWER42_SQ_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

