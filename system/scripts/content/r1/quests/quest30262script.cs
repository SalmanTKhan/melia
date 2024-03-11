//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vincentas.
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

[QuestScript(30262)]
public class Quest30262Script : QuestScript
{
	protected override void Load()
	{
		SetId(30262);
		SetName("Assassin Ebonypawn(7)");
		SetDescription("Talk to Vincentas");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_8"));

		AddObjective("kill0", "Kill 10 Black Shardstatue(s) or Black Templeslave(s) or Black Temple Slave Assassin(s)", new KillObjective(10, 58497, 58498, 58499));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("CASTLE_20_4_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_4_SQ_9_select", "CASTLE_20_4_SQ_9", "The assassin shall fall.", "I need some time to prepare myself."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_4_SQ_9_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

