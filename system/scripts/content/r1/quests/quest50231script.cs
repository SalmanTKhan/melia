//--- Melia Script -----------------------------------------------------------
// Weeding(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Kidas.
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

[QuestScript(50231)]
public class Quest50231Script : QuestScript
{
	protected override void Load()
	{
		SetId(50231);
		SetName("Weeding(2)");
		SetDescription("Talk to Priest Kidas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN43_4_SQ10_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ9"));

		AddObjective("kill0", "Kill 6 Vilkas Fighter(s) or Vilkas Spearman(s)", new KillObjective(6, 58458, 58456));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ9_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ10_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ10_START1", "BRACKEN43_4_SQ10", "Agree to search for Priest Brunas", "Say that he will come if you wait here"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("BRACKEN43_4_SQ10_SUCC1");
		dialog.HideNPC("BRACKEN434_SUBQ10_NPC2");
		dialog.HideNPC("BRACKEN434_SUBQ9_NPC2");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("BRACKEN434_SUBQ10_NPC3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

