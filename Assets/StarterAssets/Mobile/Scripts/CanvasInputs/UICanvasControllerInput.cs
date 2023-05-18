using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public PlayerController starterAssetsInputs;
        public ThirdPersonShooter thirdPersonShooterInputs;

        public void VirtualMoveInput(InputAction.CallbackContext context)
        {
            starterAssetsInputs.Move(context);
        }

        public void VirtualLookInput(InputAction.CallbackContext context)
        {
            starterAssetsInputs.Look(context);
        }

        public void VirtualShootInput(InputAction.CallbackContext context)
        {
            thirdPersonShooterInputs.Fire(context);
        }
        /*
        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }
        */
        
    }

}
