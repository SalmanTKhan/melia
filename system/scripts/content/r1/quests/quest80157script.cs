//--- Melia Script -----------------------------------------------------------
// With the Power of the Goddess (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
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

[QuestScript(80157)]
public class Quest80157Script : QuestScript
{
	protected override void Load()
	{
		SetId(80157);
		SetName("With the Power of the Goddess (2)");
		SetDescription("Talk to Goddess Saule");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_8"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("LIMESTONE_52_4_MQ_8_KEY_HOLY", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 150192));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_9_start", "LIMESTONE_52_4_MQ_9", "I'll find it and repair it.", "Just wait a little longer."))
		{
			case 1:
				dialog.UnHideNPC("LIMESTONE_52_4_MQ_9_ORB");
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

		dialog.HideNPC("LIMESTONE_52_4_MQ_9_ORB");
		await dialog.Msg("LIMESTONE_52_4_MQ_9_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

