//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 2 [Quarrel Shooter Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Quarrel Shooter Master.
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

[QuestScript(1090)]
public class Quest1090Script : QuestScript
{
	protected override void Load()
	{
		SetId(1090);
		SetName("Dream Book of the Bow 2 [Quarrel Shooter Advancement] (4)");
		SetDescription("Talk to the Quarrel Shooter Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_QUARREL2_3"));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL2_4_select1", "JOB_QUARREL2_4", "I'll deliver the pouch", "I'll quit here"))
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

		ZoneServer.Instance.World.FindNPC("MASTER_QU")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
		await dialog.Msg("JOB_QUARREL2_4_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

