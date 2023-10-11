//--- Melia Script -----------------------------------------------------------
// Destroying the Obelisks (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Antanina.
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

[QuestScript(72231)]
public class Quest72231Script : QuestScript
{
	protected override void Load()
	{
		SetId(72231);
		SetName("Destroying the Obelisks (1)");
		SetDescription("Talk to Resistance Adjutant Antanina");

		AddPrerequisite(new LevelPrerequisite(398));
		AddPrerequisite(new CompletedPrerequisite("CASTLE95_MAIN01"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE95_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE95_OBELISK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE95_MAIN02_01", "CASTLE95_MAIN02", "Alright", "I'll have to think about it."))
		{
			case 1:
				await dialog.Msg("CASTLE95_MAIN02_02");
				// Func/SCR_CASTLE95_MAIN02_START;
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

		await dialog.Msg("BalloonText/CASTLE95_MAIN02_MONOLOG1/5");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "[Destroying the Obelisks (1)]{nl}Quest complete!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE95_MAIN03");
	}
}

