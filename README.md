# Demo Azure Functions with Dynamics

Simple example for how to call Azure Function from Microsoft Dynamics and back from Azure Function to Microsoft Dynamics. You will need a working [Dynamics](https://dynamics.microsoft.com/en-us/) tenant in order to function.

## Instructions

In order to get the result to Azure Function you will need to configure webhook to react on **create** contact. To register the webhook, you will need [CDS SDK](https://www.cds.tools/). Download and install SDK. You will get structure as follows.

![Folder structure](https://csacoresettings.blob.core.windows.net/public/Dynamics-Plugin-Folder-Structure.png)

Get in Plugin Registration and run the plugin registration tool - **PluginRegistration.exe**.

![Login hook](https://csacoresettings.blob.core.windows.net/public/Dynamics-plugin-registration-tool.png)

After that you can easily **register web hook**.

![register webhook](https://csacoresettings.blob.core.windows.net/public/Dynamics-plugin-registration-tool-Register-Web-hook.png)

After entering details, you will need to **register step**, where this webhook will be used.

![register new step](https://csacoresettings.blob.core.windows.net/public/Dynamics-plugin-registration-tool-Register-Step.png)

After selecting on what to react to (CREATE, EDIT, CALCULATIONS,...), you can select the hook to be called (you can react multiple steps).

![step entry](https://csacoresettings.blob.core.windows.net/public/Dynamics-plugin-registration-tool-Register-Step-Handler.png)

When you create contact, you should get the response and then it is up to you.

![webhook response](https://csacoresettings.blob.core.windows.net/public/Contact-Model-json-Dynamics.png)




