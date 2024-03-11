//--- Melia Script -----------------------------------------------------------
// Change of One's Thinking
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gelija.
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

[QuestScript(60144)]
public class Quest60144Script : QuestScript
{
	protected override void Load()
	{
		SetId(60144);
		SetName("Change of One's Thinking");
		SetDescription("Talk with Priest Gelija");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_GELIYA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_GELIYA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON623_SQ_03_01", "PRISON623_SQ_03", "I'll purify it", "Don't worry so much"))
		{
			case 1:
				await dialog.Msg("PRISON623_SQ_03_01_AG");
				dialog.UnHideNPC("PRISON623_SQ_03_NPC");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "The fragments of the destroyed idol are spread throughout 3F.{nl}Find and purify them!", 10);
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

