//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Skywa.
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

[QuestScript(60268)]
public class Quest60268Script : QuestScript
{
	protected override void Load()
	{
		SetId(60268);
		SetName("The History that Will Not Be Recorded (6)");
		SetDescription("Talk to Kupole Skywa");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_5"));

		AddObjective("kill0", "Kill 24 Lapinel(s) or Raphindal(s) or Wiznoll(s) or Rampal(s)", new KillObjective(24, 58417, 58404, 58403, 58406));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_SJAIVA_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB484_MQ_6_1", "FANTASYLIB484_MQ_6", "I'll take care of it", "I need to prepare"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1500");
				dialog.HideNPC("FLIBRARY484_SJAIVA_NPC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FANTASYLIB484_MQ_7");
	}
}

