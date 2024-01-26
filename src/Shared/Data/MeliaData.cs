using Melia.Shared.Data.Database;

namespace Melia.Shared.Data
{
	/// <summary>
	/// Wrapper for all file databases.
	/// </summary>
	public class MeliaData
	{
		public AbilityDb AbilityDb { get; } = new AbilityDb();
		public AbilityTreeDb AbilityTreeDb { get; } = new AbilityTreeDb();
		public AccountOptionDb AccountOptionDb { get; } = new AccountOptionDb();
		public AchievementDb AchievementDb { get; } = new AchievementDb();
		public AchievementPointDb AchievementPointDb { get; } = new AchievementPointDb();
		public BarrackDb BarrackDb { get; } = new BarrackDb();
		public BuffDb BuffDb { get; } = new BuffDb();
		public CabinetDb CabinetDb { get; } = new CabinetDb();
		public ChatEmoticonDb ChatEmoticonDb { get; } = new ChatEmoticonDb();
		public ChatMacroDb ChatMacroDb { get; } = new ChatMacroDb();
		public CollectionDb CollectionDb { get; } = new CollectionDb();
		public CooldownDb CooldownDb { get; } = new CooldownDb();
		public CustomCommandDb CustomCommandDb { get; } = new CustomCommandDb();
		public DialogDb DialogDb { get; } = new DialogDb();
		public DialogTxDb DialogTxDb { get; } = new DialogTxDb();
		public ExpDb ExpDb { get; } = new ExpDb();
		public FactionDb FactionDb { get; } = new FactionDb();
		public FeatureDb FeatureDb { get; } = new FeatureDb();
		public FurnitureDb FurnitureDb { get; } = new FurnitureDb();
		public GroundDb GroundDb { get; } = new GroundDb();
		public HairTypeDb HairTypeDb { get; } = new HairTypeDb();
		public HelpDb HelpDb { get; } = new HelpDb();
		public InstanceDungeonDb InstanceDungeonDb { get; } = new InstanceDungeonDb();
		public InvBaseIdDb InvBaseIdDb { get; } = new InvBaseIdDb();
		public ItemDb ItemDb { get; } = new ItemDb();
		public ItemMonsterDb ItemMonsterDb { get; } = new ItemMonsterDb();
		public JobDb JobDb { get; } = new JobDb();
		public MapDb MapDb { get; } = new MapDb();
		public MonsterDb MonsterDb { get; } = new MonsterDb();
		public NormalTxDb NormalTxDb { get; } = new NormalTxDb();
		public PacketStringDb PacketStringDb { get; } = new PacketStringDb();
		public PropertiesDb PropertiesDb { get; } = new PropertiesDb();
		public QuestDb QuestDb { get; } = new QuestDb();
		public RecipeDb RecipeDb { get; } = new RecipeDb();
		public ResurrectionPointDb ResurrectionPointDb { get; } = new ResurrectionPointDb();
		public SelectItemDb SelectItemDb { get; } = new SelectItemDb();
		public ServerDb ServerDb { get; }
		public SessionObjectDb SessionObjectDb { get; } = new SessionObjectDb();
		public ShopDb ShopDb { get; } = new ShopDb();
		public SkillDb SkillDb { get; } = new SkillDb();
		public SkillTreeDb SkillTreeDb { get; } = new SkillTreeDb();
		public StanceConditionDb StanceConditionDb { get; } = new StanceConditionDb();
		public SystemMessageDb SystemMessageDb { get; } = new SystemMessageDb();
		public TradeShopDb TradeShopDb { get; }
		public WarpDb WarpDb { get; } = new WarpDb();

		public MeliaData()
		{
			// Not entirely happy with this design, but I want access to
			// the map list from the server db to determine which maps
			// the zone servers serve.
			this.ServerDb = new ServerDb(this.MapDb);
			this.TradeShopDb = new TradeShopDb(this.ItemDb);
		}
	}
}
