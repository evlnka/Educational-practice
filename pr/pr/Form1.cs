using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace pr
{
    public partial class Form1 : Form
    {
        private PowerSupply[] powerSupplies;
        private string currentFilePath;
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            dataGridView.DataSource = bindingSource;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";
                openFileDialog.Title = "Открыть файл блоков питания";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    LoadFile(currentFilePath);
                    UpdateFileInfo();
                }
            }
        }

        private void LoadFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                var list = new System.Collections.Generic.List<PowerSupply>();

                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length == 5)
                    {
                        var ps = new PowerSupply
                        {
                            ModelName = parts[0].Trim(),
                            OutputVoltage = Convert.ToDouble(parts[1].Trim()),
                            InputVoltage = Convert.ToDouble(parts[2].Trim()),
                            Power = Convert.ToDouble(parts[3].Trim()),
                            HasCooling = parts[4].Trim().Equals("Active", StringComparison.OrdinalIgnoreCase)
                        };
                        list.Add(ps);
                    }
                }

                powerSupplies = list.ToArray();
                bindingSource.DataSource = powerSupplies;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFileInfo()
        {
            if (File.Exists(currentFilePath))
            {
                var info = new FileInfo(currentFilePath);
                lblFileName.Text = $"Файл: {info.Name}";
                lblFileSize.Text = $"Размер: {info.Length} байт";
                lblLastModified.Text = $"Изменен: {info.LastWriteTime}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFileLoaded()) return;

            try
            {
                var lines = new string[powerSupplies.Length];
                for (int i = 0; i < powerSupplies.Length; i++)
                {
                    var ps = powerSupplies[i];
                    lines[i] = $"{ps.ModelName}, {ps.OutputVoltage}, {ps.InputVoltage}, {ps.Power}, {(ps.HasCooling ? "Active" : "Passive")}";
                }

                File.WriteAllLines(currentFilePath, lines);
                MessageBox.Show("Изменения успешно сохранены.", "Сохранение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateFileInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearchModel.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Введите модель для поиска", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFileLoaded()) return;

            foreach (var ps in powerSupplies)
            {
                if (ps.ModelName.Equals(search, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        $"Модель: {ps.ModelName}\n" +
                        $"Выходное напряжение: {ps.OutputVoltage} В\n" +
                        $"Входное напряжение: {ps.InputVoltage} В\n" +
                        $"Мощность: {ps.Power} Вт\n" +
                        $"Охлаждение: {(ps.HasCooling ? "Да" : "Нет")}",
                        "Результат поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show($"Модель '{search}' не найдена", "Результат поиска",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "DAT files (*.dat)|*.dat";
                saveDialog.Title = "Создать тестовый файл";
                saveDialog.FileName = "power_supplies.dat";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    CreateTestFile(saveDialog.FileName);
                    MessageBox.Show("Тестовый файл создан.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CreateTestFile(string filePath)
        {
            var testData = new PowerSupply[20];
            var rnd = new Random();

            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = new PowerSupply
                {
                    ModelName = $"Model_{i + 1}",
                    OutputVoltage = Math.Round(5 + rnd.NextDouble() * 20, 2),
                    InputVoltage = Math.Round(100 + rnd.NextDouble() * 100, 2),
                    Power = 100 + rnd.Next(500),
                    HasCooling = rnd.Next(2) == 1
                };
            }

            var lines = new string[testData.Length];
            for (int i = 0; i < testData.Length; i++)
            {
                var ps = testData[i];
                lines[i] = $"{ps.ModelName}, {ps.OutputVoltage}, {ps.InputVoltage}, {ps.Power}, {(ps.HasCooling ? "Active" : "Passive")}";
            }

            File.WriteAllLines(filePath, lines);
        }

        private bool ValidateFileLoaded()
        {
            if (powerSupplies == null || powerSupplies.Length == 0)
            {
                MessageBox.Show("Файл не загружен или не содержит данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ▶ Добавлено: кнопка "О программе"
        private void btnAbout_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void ShowAboutDialog()
        {
            MessageBox.Show(
                "Разработчик: Коваленко Евангелина Александровна\n" +
                "Группа: ИА-331\n" +
                "СибГУТИ, 2025 год",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Разработчик: Коваленко Евангелина Александровна\n" +
                "Курс: 2\n" +
                "Группа: ИА-331\n" +
                "СибГУТИ, 2025 год",
                "О программе",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }
    }

    public class PowerSupply
    {
        [DisplayName("Модель")]
        public string ModelName { get; set; }

        [DisplayName("Выходное напряжение (В)")]
        public double OutputVoltage { get; set; }

        [DisplayName("Входное напряжение (В)")]
        public double InputVoltage { get; set; }

        [DisplayName("Мощность (Вт)")]
        public double Power { get; set; }

        [DisplayName("Охлаждение")]
        public bool HasCooling { get; set; }
    }
}
