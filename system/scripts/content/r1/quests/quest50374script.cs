//--- Melia Script -----------------------------------------------------------
// Velcoffer Armor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Teliavelis.
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

[QuestScript(50374)]
public class Quest50374Script : QuestScript
{
	protected override void Load()
	{
		SetId(50374);
		SetName("Velcoffer Armor (2)");
		SetDescription("Talk to Teliavelis");

		AddPrerequisite(new LevelPrerequisite(360));
		AddPrerequisite(new CompletedPrerequisite("VELCOFFER_MQ1"));

		AddDialogHook("FEDIMIAN_TERIAVELIS", "BeforeStart", BeforeStart);
		AddDialogHook("FEDIMIAN_TERIAVELIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VELCOFFER_MQ2_START1", "VELCOFFER_MQ2", "Here, take them.", "I'll hold on to them for now."))
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

		await dialog.Msg("VELCOFFER_MQ2_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

