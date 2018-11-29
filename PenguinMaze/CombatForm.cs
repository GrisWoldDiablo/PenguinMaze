using PenguinMaze.Classes;
using PenguinMaze.Classes.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinMaze
{
    public partial class CombatForm : Form
    {
        public AbstractEntity attacker;
        public AbstractEntity target;

        public CombatForm()
        {
            InitializeComponent();
        }

        public void StartCombat(AbstractEntity attacker, AbstractEntity target)
        {
            this.Show();
            this.attacker = attacker;
            this.target = target;
            UpdateFightInfo();
        }

        private void Attacker_PB_Paint(object sender, PaintEventArgs e)
        {
            attacker.Draw(e.Graphics,null,attacker_PB.Width);
        }

        private void Target_PB_Paint(object sender, PaintEventArgs e)
        {
            target.Draw(e.Graphics, null, target_PB.Width);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameManager.CombatUpdate();
            UpdateFightInfo();
        }
        
        private void UpdateFightInfo()
        {
            attackerHP_TB.Text = attacker.HealthPoint.ToString();
            targetHP_TB.Text = target.HealthPoint.ToString();
        }
    }
}
