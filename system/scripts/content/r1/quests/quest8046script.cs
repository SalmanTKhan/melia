//--- Melia Script -----------------------------------------------------------
// Information about Saugas (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Eta.
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

[QuestScript(8046)]
public class Quest8046Script : QuestScript
{
	protected override void Load()
	{
		SetId(8046);
		SetName("Information about Saugas (3)");
		SetDescription("Talk to Mercenary Eta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS26_SUB_Q10_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q09"));

		AddObjective("kill0", "Kill 6 Sauga(s)", new KillObjective(6, MonsterId.Sauga_S));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_EHTA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_EHTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_SUB_Q10_01", "ROKAS26_SUB_Q10", "I will try", "Tell him to do it himself"))
		{
			case 1:
				dialog.UnHideNPC("ROKAS26_SUB_Q10_TRIGGER");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS26_SUB_Q10_03");
		dialog.HideNPC("ROKAS26_SUB_Q10_TRIGGER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS26_SUB_Q11");
	}
}

