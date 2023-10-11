//--- Melia Script -----------------------------------------------------------
// A Soldier's Mission
//--- Description -----------------------------------------------------------
// Quest to Talk to the resentful soldier.
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

[QuestScript(9106)]
public class Quest9106Script : QuestScript
{
	protected override void Load()
	{
		SetId(9106);
		SetName("A Soldier's Mission");
		SetDescription("Talk to the resentful soldier");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_BOSSKILL_1"));

		AddObjective("kill0", "Kill 50 Kepa Raider(s) or Infro Holder(s) or Ducky(s) or Infro Hoglan(s) or Cronewt(s)", new KillObjective(50, 41288, 41298, 57035, 57037, 57036));

		AddDialogHook("THORN_23_HQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("THORN_23_HQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN_23_HQ_01_select01", "THORN_23_HQ_01", "I'll complete the mission for you", "Refuse"))
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

		await dialog.Msg("THORN_23_HQ_01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

