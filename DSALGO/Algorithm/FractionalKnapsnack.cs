namespace DSALGO.Algorithm {
    public class FractionalKnapsnack {
        struct Item {
            public int profit;
            public int weight;
            public int value;
            public Item(int weight, int profit) {
                this.weight = weight;
                this.profit = profit;
                value = profit / weight;
            }

        }
        public int GetMaxProfit(int[] weights, int[] profits, int capacity) {
            int length = weights.Length;
            List<Item> items = new List<Item>();
            for (int i = 0; i < length; i++) {
                items.Add(new Item(weights[i], profits[i]));
            }
            items.OrderByDescending(x => x.value);
            int loaded = 0;
            int earn = 0;
            for (int i = 0; i < length; i++) {  // O(n)
                if(loaded + items[i].weight < capacity) {
                    earn += items[i].profit;
                    loaded += items[i].weight;
                }
                else {
                    // 裝滿了
                    earn += items[i].value * (capacity - loaded);
                    break;
                }
            }
            return earn;
        }
    }
}
/*
int[] weis = new int[] { 850, 300, 500, 200 };
int[] pros = new int[] { 400, 150, 150, 120 };
FractionalKnapsnack algo = new();
algo.GetMaxProfit(weis, pros, 1000);
 */