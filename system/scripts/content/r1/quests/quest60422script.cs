//--- Melia Script -----------------------------------------------------------
// Cries and Echoes
//--- Description -----------------------------------------------------------
// Quest to Talk to Ineta.
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

[QuestScript(60422)]
public class Quest60422Script : QuestScript
{
	protected override void Load()
	{
		SetId(60422);
		SetName("Cries and Echoes");
		SetDescription("Talk to Ineta");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE98_MQ_1"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23028));

		AddDialogHook("CASTLE98_MQ_INETA_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE98_MQ_2_1", "CASTLE98_MQ_2", "Alright, I'll help you", "Not my problem, you can do it yourself."))
		{
			case 1:
				dialog.UnHideNPC("CASTLE98_MQ_2_NPC");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Use the Time Meter Necklace on the Grave of the Nameless and{nl}find the Lever Pieces.");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

