using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace ShapesLib.Design
{
	internal class BaseEditor : UITypeEditor
	{
		// Methods
		public BaseEditor()
		{
			this.editorService = null;
		}


		// Fields
		protected IWindowsFormsEditorService editorService;
	}
}

