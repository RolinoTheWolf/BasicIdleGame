using System.Collections.Generic;
using System.Linq;

public class Helper {

    public static void UpgradeCheck<T>(ref List<T> list, int length) where T : new() {
        try {
            if (list == null || list.Count == 0) list = new T[length].ToList();

            while (list.Count < length) {
                list.Add(new T());
            }
        } catch {
            list = new T[length].ToList();
        }
    }

}
