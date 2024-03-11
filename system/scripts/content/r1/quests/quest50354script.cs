//--- Melia Script -----------------------------------------------------------
// Everything will go as we planned.
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

[QuestScript(50354)]
public class Quest50354Script : QuestScript
{
	protected override void Load()
	{
		SetId(50354);
		SetName("Everything will go as we planned.");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ10"));

		AddDialogHook("ABBEY22_4_SUBQ11_FLURRY", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ11_FLURRY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ11_START1", "ABBEY22_4_SQ11", "Listen to further plans.", "It's getting more dangerous by the minute."))
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

		await dialog.Msg("ABBEY22_4_SUBQ11_SUCC1");
		ZoneServer.Instance.World.FindNPC("ABBEY22_4_SUBQ11_FLURRY")?.PlayEffectLocal(character.Connection, "F_buff_basic028_violet_line", 1f, "BOT");
		dialog.HideNPC("ABBEY22_4_SUBQ11_FLURRY");
		dialog.UnHideNPC("ABBEY225_FLURRY1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

