using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFilesManager.Presenters {
  public class PairsList : IRefreshablePresenter, ISelectableControl {
    public delegate void PairChanged(String main_item, String sub_item);
    public PairChanged PairChangedProcessor;
    public String MainItem {
      get { return (String)main_list.SelectedItem; }
    }
    public String SubItem {
      get { return (String)sub_list.SelectedItem; }
    }

    ListBox main_list, sub_list;
    List<String> items;

    public PairsList(ListBox main_list, ListBox sub_list) {
      this.main_list = main_list;
      this.sub_list = sub_list;
      this.main_list.SelectedIndexChanged += new System.EventHandler(this.selectedMainIndexChanged);
      this.sub_list.SelectedIndexChanged += new System.EventHandler(this.selectedSubIndexChanged);
      this.items = new List<string>();
    }

    public void RefreshWith(ImageFile[] images) {
      Clear();
      AddItems(images.Select((i) => i.FileName).ToArray());
    }

    public string[] SelectedItems() {
      return new String[] { MainItem, SubItem };
    }

    public void AddSelectionChangeHandler(EventHandler handler) {
      this.main_list.SelectedIndexChanged += handler;
      this.sub_list.SelectedIndexChanged += handler;
    }

    public void AddItems(String[] items) {
      this.items.AddRange(items);
      refreshMainList();
    }

    public void Clear() {
      this.items.Clear();
      refreshMainList();
    }

    void refreshMainList() {
      main_list.Items.Clear();
      foreach (var item in items) {
        main_list.Items.Add(item);
      }
      if (main_list.Items.Count > 0)
        main_list.SelectedIndex = 0;
    }

    void refreshSubList() {
      sub_list.Items.Clear();
      if (main_list.Items.Count < 2)
        return;
      for (var i_item = 0; i_item < items.Count; i_item++)
        if (i_item != main_list.SelectedIndex)
          sub_list.Items.Add(main_list.Items[i_item]);
      sub_list.SelectedIndex = 0;
    }

    void selectedMainIndexChanged(object sender, EventArgs e) {
      refreshSubList();
      if (PairChangedProcessor != null)
        PairChangedProcessor.Invoke(MainItem, SubItem);
    }

    void selectedSubIndexChanged(object sender, EventArgs e) {
      if (PairChangedProcessor != null)
        PairChangedProcessor.Invoke(MainItem, SubItem);
    }
  }
}
