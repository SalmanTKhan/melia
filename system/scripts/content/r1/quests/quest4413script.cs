//--- Melia Script -----------------------------------------------------------
// Missing Researcher (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Dezic.
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

[QuestScript(4413)]
public class Quest4413Script : QuestScript
{
	protected override void Load()
	{
		SetId(4413);
		SetName("Missing Researcher (1)");
		SetDescription("Talk to Archaeologist Dezic");

		AddPrerequisite(new LevelPrerequisite(67));

		AddObjective("kill0", "Kill 15 Sauga(s) or Ticen(s) or Tucen(s) or Loftlem(s)", new KillObjective(15, 401001, 57045, 57046, 57041));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_DESIG_01", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_DESIG_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_QB_1_select1", "ROKAS27_QB_1", "Alright, I'll help you", "Just go"))
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

		await dialog.Msg("ROKAS27_QB_1_succ1");
		dialog.HideNPC("ROKAS27_DESIG_01");
		ZoneServer.Instance.World.FindNPC("ROKAS27_DESIG_01")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("ROKAS27_DESIG_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

