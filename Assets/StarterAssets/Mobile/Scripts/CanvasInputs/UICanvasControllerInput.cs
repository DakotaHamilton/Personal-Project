using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public PlayerController starterAssetsInputs;
        public ThirdPersonShooter thirdPersonShooterInputs;

        public void VirtualMoveInput(Vector2 context)
        {
            starterAssetsInputs.MoveInput(context);
        }

        public void VirtualLookInput(Vector2 context)
        {
            starterAssetsInputs.LookInput(context);
        }

        public void VirtualShootInput(bool input)
        {
            thirdPersonShooterInputs.FireInput(input);
        }

        public void VirtualPauseInput(bool input)
        {
            thirdPersonShooterInputs.PauseInput(input);
        }
        
    }

}
