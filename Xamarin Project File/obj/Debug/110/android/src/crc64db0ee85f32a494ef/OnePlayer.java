package crc64db0ee85f32a494ef;


public class OnePlayer
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("IT123P_Final_Course_Assessment_MP.OnePlayer, IT123P_Final_Course_Assessment_MP", OnePlayer.class, __md_methods);
	}


	public OnePlayer ()
	{
		super ();
		if (getClass () == OnePlayer.class)
			mono.android.TypeManager.Activate ("IT123P_Final_Course_Assessment_MP.OnePlayer, IT123P_Final_Course_Assessment_MP", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
