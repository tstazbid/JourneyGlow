using JourneyGlow.Data;
using JourneyGlow.Models.Domain;
using JourneyGlow.Models.ViewModels;
using JourneyGlow.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace JourneyGlow.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;
        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            ValidateAddTagRequest(addTagRequest);

            if (!ModelState.IsValid)
            {
                return View();
            }

            // var name = addTagRequest.Name;
            // var displayName = addTagRequest.DisplayName;

            // Mapping AddTagRequest to Tag Domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            // use dbContest to read the tags
            var tags = await tagRepository.GetAllAsync();

            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);

            if (tag != null) {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            } 

            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if(updatedTag != null)
            {
                // show success notification
            } else
            {
                // show error notification
            }

            // Show error notification
            return RedirectToAction("Edit", new {id = editTagRequest.Id});
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deleteTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deleteTag != null)
            {
                // show successful delete notification
                return RedirectToAction("List");
            }

            // showing a error to delete the tag
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }


        private void ValidateAddTagRequest(AddTagRequest addTagRequest)
        {
            if(addTagRequest.Name != null && addTagRequest.DisplayName != null)
            {
                if(addTagRequest.Name == addTagRequest.DisplayName)
                {
                    ModelState.AddModelError("DisplayName", "Name cannot be same as display name!");
                }
            }
        }
    }
}
