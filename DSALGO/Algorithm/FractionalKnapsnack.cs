namespace DSALGO.Algorithm; 
public class FractionalKnapsack {
    struct Item {
        public int profit;
        public int weight;
        public double value;

        public Item(int weight, int profit) {
            this.weight = weight;
            this.profit = profit;
            value = (double)profit / weight;
        }
    }

    public double GetMaxProfit(int[] weights, int[] profits, int capacity) {
        int length = weights.Length;
        List<Item> items = [];

        for (int i = 0; i < length; i++) {
            items.Add(new Item(weights[i], profits[i]));
        }

        // ✅ 這裡要真的排序，否則沒有效果
        items = items.OrderByDescending(x => x.value).ToList();

        double earn = 0;
        int loaded = 0;

        for (int i = 0; i < length && loaded < capacity; i++) {
            if (loaded + items[i].weight <= capacity) {
                // 整個拿
                earn += items[i].profit;
                loaded += items[i].weight;
            }
            else {
                // 拿一部分
                int remain = capacity - loaded;
                earn += items[i].value * remain;
                loaded += remain;
                break; // 背包滿了
            }
        }
        return earn;
    }
}
/*
int[] weis = new int[] { 850, 300, 500, 200 };
int[] pros = new int[] { 400, 150, 150, 120 };
FractionalKnapsnack algo = new();
algo.GetMaxProfit(weis, pros, 1000);
*/