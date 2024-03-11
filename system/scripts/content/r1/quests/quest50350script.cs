//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50350)]
public class Quest50350Script : QuestScript
{
	protected override void Load()
	{
		SetId(50350);
		SetName("In to the Lion's Mouth (7)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ6"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18054));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY22_4_SUBQ5_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ7_UNKNOWN_OBJ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ7_START1", "ABBEY22_4_SQ7", "Go to the area.", "Go on ahead."))
		{
			case 1:
				await dialog.Msg("BalloonText/ABBEY22_4_SUBQ7_MSG2/4");
				dialog.UnHideNPC("ABBEY22_4_SUBQ7_NPC1");
				dialog.HideNPC("ABBEY22_4_SUBQ5_NPC1");
				await dialog.Msg("FadeOutIN/1000");
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


		return HookResult.Break;
	}
}

