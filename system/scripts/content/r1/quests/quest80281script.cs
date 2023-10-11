//--- Melia Script -----------------------------------------------------------
// Conciliating the Enemy
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resistance Adjutant Taylor.
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

[QuestScript(80281)]
public class Quest80281Script : QuestScript
{
	protected override void Load()
	{
		SetId(80281);
		SetName("Conciliating the Enemy");
		SetDescription("Talk to the Resistance Adjutant Taylor");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_18"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_SQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_SQ_04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_SQ_04_ST", "F_3CMLAKE_86_SQ_04", "I'll do it.", "I don't think it's going to work."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_SQ_04_AFST");
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

		await dialog.Msg("F_3CMLAKE_86_SQ_04_SU");
		dialog.HideNPC("F_3CMLAKE_86_SQ_04_CONFUSE_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

