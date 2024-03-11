//--- Melia Script -----------------------------------------------------------
// Long Dreams Are Dreamt at Narvas Temple (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50369)]
public class Quest50369Script : QuestScript
{
	protected override void Load()
	{
		SetId(50369);
		SetName("Long Dreams Are Dreamt at Narvas Temple (2)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ14"));

		AddDialogHook("ABBEY225_FLURRY5", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_FLURRY5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_5_SUBQ15_START1", "ABBEY22_5_SQ15", "What will happen, then?", "Good work. I'll get going now."))
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

		await dialog.Msg("ABBEY22_5_SUBQ15_SUUC1");
		ZoneServer.Instance.World.FindNPC("ABBEY225_FLURRY5")?.PlayEffectLocal(character.Connection, "F_buff_basic028_violet_line", 1f, "BOT");
		dialog.HideNPC("ABBEY225_FLURRY5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

