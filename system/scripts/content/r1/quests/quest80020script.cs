//--- Melia Script -----------------------------------------------------------
// Reclaiming Food
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Leja.
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

[QuestScript(80020)]
public class Quest80020Script : QuestScript
{
	protected override void Load()
	{
		SetId(80020);
		SetName("Reclaiming Food");
		SetDescription("Talk to Druid Leja");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_02"));

		AddObjective("collect0", "Collect 10 Stolen Food by Ferrets(s)", new CollectItemObjective("ORCHARD_323_MQ_03_ITEM2", 10));
		AddDrop("ORCHARD_323_MQ_03_ITEM2", 10f, 57852, 57853, 57854);

		AddReward(new ExpReward(491420, 491420));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1840));
		AddReward(new ItemReward("Drug_SP2_Q", 20));

		AddDialogHook("ORCHARD323_LEJA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_MQ_03_start", "ORCHARD_323_MQ_03", "I am the Revelator", "Stay quiet"))
		{
			case 1:
				await dialog.Msg("ORCHARD_323_MQ_03_agree");
				// Func/ORCHARD_HIDE;
				dialog.HideNPC("ORCHARD323_LEJA");
				dialog.UnHideNPC("ORCHARD342_LEJA");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_323_MQ_04");
	}
}

