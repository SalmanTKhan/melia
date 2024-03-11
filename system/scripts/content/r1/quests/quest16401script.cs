//--- Melia Script -----------------------------------------------------------
// Secret of the Farmland (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Raeli.
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

[QuestScript(16401)]
public class Quest16401Script : QuestScript
{
	protected override void Load()
	{
		SetId(16401);
		SetName("Secret of the Farmland (1)");
		SetDescription("Talk with Priest Raeli");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_2_MQ_01_01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(166));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_3_MQ_05"));

		AddObjective("kill0", "Kill 8 Chupaluka(s) or Big Black Griba(s)", new KillObjective(8, 41442, 57219));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_2_MQ_01_01_select", "SIAULIAI_46_2_MQ_01_01", "I will activate the Guardian Stone", "About the treatment at Vilna Forest", "Let's just leave it"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_2_MQ_01_01_start_prog");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_46_2_MQ_01_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAULIAI_46_2_MQ_01_01_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_2_MQ_01");
	}
}

