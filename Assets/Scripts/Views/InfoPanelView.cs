using System.Globalization;
using Base;
using Presenters;
using TMPro;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Views
{
    public class InfoPanelView : BaseView<InfoPanelPresenter>
    {
        [SerializeField] private TextMeshProUGUI positionText;
        [SerializeField] private TextMeshProUGUI angleText;
        [SerializeField] private TextMeshProUGUI speedText;
        [SerializeField] private TextMeshProUGUI laserAmmoText;
        [SerializeField] private TextMeshProUGUI laserRollbackTimeText;

        public void DisplayPosition(Vector2 position)
        {
            positionText.text = position.ToString("F2");
        }
        
        public void DisplayAngle(float angle)
        {
            angleText.text = angle.ToString("0.00 °", CultureInfo.InvariantCulture);
        }
        
        public void DisplaySpeed(float speed)
        {
            speedText.text = speed.ToString("F1", CultureInfo.InvariantCulture);
        }
        
        public void DisplayLaserAmmo(int ammo)
        {
            laserAmmoText.text = ammo.ToString();
        }
        
        public void DisplayLaserRollbackTime(float time)
        {
            laserRollbackTimeText.text = time.ToString("F1", CultureInfo.InvariantCulture);
        }
    }
}