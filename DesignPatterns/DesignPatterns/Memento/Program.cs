
using System;

namespace MementoPatternExample
{
    // 1. ذخیره وضعیت قبلی
    public class EditorMemento
    {
        public string Text { get; }

        public EditorMemento(string text)
        {
            Text = text;
        }
    }

    // 2. شیئی که وضعیتش ذخیره و بازیابی می‌شود
    public class TextEditor
    {
        public string Text { get; set; } = string.Empty;

        // ایجاد نسخه‌ای از وضعیت فعلی
        public EditorMemento Save()
        {
            return new EditorMemento(Text);
        }

        // بازیابی وضعیت ذخیره‌شده
        public void Restore(EditorMemento memento)
        {
            Text = memento.Text;
        }
    }

    // 3. نگهداری نسخه ذخیره‌شده
    public class History
    {
        private EditorMemento _memento;

        public void Save(EditorMemento memento)
        {
            _memento = memento;
        }

        public EditorMemento GetSavedState()
        {
            return _memento;
        }
    }

    // 4. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            History history = new History();

            editor.Text = "Hello";
            history.Save(editor.Save());

            editor.Text = "Hello World";
            Console.WriteLine("Current: " + editor.Text);

            // بازگرداندن متن به وضعیت ذخیره‌شده
            editor.Restore(history.GetSavedState());

            Console.WriteLine("After Undo: " + editor.Text);

            Console.ReadKey();
        }
    }
}
