//--- Melia Script -----------------------------------------------------------
// Something's Bugging You, Scout? (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Soul of the Scout.
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

[QuestScript(30272)]
public class Quest30272Script : QuestScript
{
	protected override void Load()
	{
		SetId(30272);
		SetName("Something's Bugging You, Scout? (3)");
		SetDescription("Talk with the Soul of the Scout");

		AddPrerequisite(new LevelPrerequisite(300));
		AddPrerequisite(new CompletedPrerequisite("KATYN_18_RE_SQ_7"));
		AddPrerequisite(new ItemPrerequisite("KATYN_18_RE_SQ_7_ITEM", -100));

		AddObjective("kill0", "Kill 17 Red Maize(s) or Red Siaulav(s) or Black Siaulav Archer(s) or Black Siaulav Mage(s)", new KillObjective(17, 58504, 58505, 58506, 58507));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_OBJ_5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_18_RE_SQ_8_select", "KATYN_18_RE_SQ_8", "Piece of cake. Count on me.", "Pointless."))
		{
			case 1:
				ZoneServer.Instance.World.FindNPC("KATYN_18_RE_SQ_NPC_3")?.PlayEffectLocal(character.Connection, "F_light077_yellow", 1.0f, "MID");
				await dialog.Msg("KATYN_18_RE_SQ_8_agree");
				dialog.HideNPC("KATYN_18_RE_SQ_NPC_3");
				await dialog.Msg("FadeOutIN/1000");
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

