//--- Melia Script -----------------------------------------------------------
// The Resentful Soldier's Spirit (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resentful Soldier's Spirit.
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

[QuestScript(50071)]
public class Quest50071Script : QuestScript
{
	protected override void Load()
	{
		SetId(50071);
		SetName("The Resentful Soldier's Spirit (2)");
		SetDescription("Talk to the Resentful Soldier's Spirit");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_SQ020"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("UNDER67_SQ030", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER_67_SQ030_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_67_SQ030_startnpc01", "UNDERFORTRESS_67_SQ030", "Let's help", "Ignore it"))
		{
			case 1:
				await dialog.Msg("UNDER_67_SQ030_startnpc02");
				ZoneServer.Instance.World.FindNPC("UNDER67_SQ030")?.PlayEffectLocal(character.Connection, "F_buff_basic025_white_line", 1f, "BOT");
				dialog.HideNPC("UNDER67_SQ030");
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


		return HookResult.Break;
	}
}

