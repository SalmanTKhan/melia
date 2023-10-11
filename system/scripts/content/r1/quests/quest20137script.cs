//--- Melia Script -----------------------------------------------------------
// Seal of the Royal Family (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gustas Jonas.
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

[QuestScript(20137)]
public class Quest20137Script : QuestScript
{
	protected override void Load()
	{
		SetId(20137);
		SetName("Seal of the Royal Family (3)");
		SetDescription("Talk to Gustas Jonas");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_REXIPHER4"));

		AddDialogHook("ROKAS25_REXIPHER5", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_REXIPHER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_REXIPHER6_01", "ROKAS25_REXIPHER6", "I'll release the final seal", "I need a minute prepare"))
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

		await dialog.Msg("ROKAS25_REXIPHER6_03");
		ZoneServer.Instance.World.FindNPC("ROKAS25_ZACHARIEL32")?.PlayEffectLocal(character.Connection, "I_force003_green", 1f, "BOT");
		dialog.UnHideNPC("ROKAS25_ZACHARIEL32");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

