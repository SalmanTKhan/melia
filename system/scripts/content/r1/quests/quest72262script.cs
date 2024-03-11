//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Laima.
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

[QuestScript(72262)]
public class Quest72262Script : QuestScript
{
	protected override void Load()
	{
		SetId(72262);
		SetName("Dusk and Dawn (3)");
		SetDescription("Talk to Goddess Laima");

		AddPrerequisite(new LevelPrerequisite(446));
		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_02"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Vis", 26314));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_FINALE_RAIMA01", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_FINALE_DIRECTION_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_FINALE_03_DLG01", "EP12_FINALE_03"))
		{
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_FINALE_04");
	}
}

