using Booking.Application.Dtos;
using Booking.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Booking.API.Controllers
{
    [ApiController]
    [Route("/slots")]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        //Qn 1a. To list only doctor's slots
        [HttpPost("/slots/doctor")]
        public async Task<IActionResult> GetSlotsByDoctor([FromBody] ListSlotByDoctorRequest request)
        {
            return Ok(await _slotService.GetSlotsByDoctor(request.doctorName));
        }

        //Qn 1b To create new slots
        [HttpPost]
        public async Task<IActionResult> CreateSlot([FromBody] CreateSlotRequest request)
        {
            await _slotService.CreateSlot(request.time, request.doctorName, request.doctorId, request.cost);
            return Ok("Slot created...");
        }

        [HttpPost("/slots/delete")]
        public async Task<IActionResult> DeleteSlot([FromBody] DeleteSlotRequest request)
        {
            await _slotService.DeleteSlot(request.slotid);
            return Ok("Slot deleted...");
        }

        //Qn 2a. To view all doctor's available slots only
        [HttpPost("/slots/getavailable")] //
        public async Task<IActionResult> GetAvailableSlots()
        {
            //return new JsonResult(_slotService.GetAvailableSlots());
            return Ok(_slotService.GetAvailableSlots());
        }

        //To view all slots irregardless of availability
        [HttpPost("/slots/getall")]
        public async Task<IActionResult> GetAllSlots()
        {
            await _slotService.GetAllSlots();
            return new JsonResult(_slotService.GetAllSlots());
        }

        //Qn 2b. API to mark slot as reserved whenever a patient books an appointment 
        [HttpPost("/slots/updatereservation")]
        public async Task<IActionResult> UpdateSlotReservation([FromBody] GetSlotUpdateRequest request)
        {
            await _slotService.UpdateSlotReservation(request.isReserved, request.slotId);
            return Ok("Reservation updated");
        }

        //Qn 3a. to retrieve the slotIds of upcoming reserved slots
        [HttpPost("/slots/upcomings")]
        public async Task<IActionResult> GetUpcomingSlots([FromBody] GetUpcomingSlotRequest request)
        {

            return Ok(_slotService.GetUpcomingSlotIds(request.doctorName));
        }







    }
}


