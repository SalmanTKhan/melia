//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (3)
//--- Description -----------------------------------------------------------
// Quest to Look for Kupole Velad.
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

[QuestScript(60300)]
public class Quest60300Script : QuestScript
{
	protected override void Load()
	{
		SetId(60300);
		SetName("The Fugitive's Dream (3)");
		SetDescription("Look for Kupole Velad");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL107_SQ_3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(378));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_2"));

		AddObjective("kill0", "Kill 5 Bishop Blanco(s)", new KillObjective(5, MonsterId.Bishop_Blanco));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 29000));

		AddDialogHook("DCAPITAL107_BLAD_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("DCAPITAL107_SQ_3_3");
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("DCAPITAL107_BLAD_NPC_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("DCAPITAL107_SQ_4");
	}
}

