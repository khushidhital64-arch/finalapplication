window.pdfExporter = {
    createPdfBase64: async function (htmlString) {
        try {
            const wrapperDiv = document.createElement("div");
            wrapperDiv.innerHTML = htmlString;
            wrapperDiv.style.padding = "20px";
            wrapperDiv.style.fontFamily = "Arial, sans-serif";

            if (!window.html2pdf) {
                console.error("html2pdf library is missing!");
                return null;
            }

            const pdfOptions = {
                margin: 10,
                filename: "export.pdf",
                image: { type: "jpeg", quality: 0.98 },
                html2canvas: { scale: 2 },
                jsPDF: { unit: "mm", format: "a4", orientation: "portrait" }
            };

            const pdfBlob = await html2pdf()
                .set(pdfOptions)
                .from(wrapperDiv)
                .outputPdf('blob');

            const buffer = await pdfBlob.arrayBuffer();
            const base64Pdf = btoa(
                new Uint8Array(buffer)
                    .reduce((data, byte) => data + String.fromCharCode(byte), '')
            );

            return base64Pdf;
        } catch (error) {
            console.error("Error while creating PDF:", error);
            return null;
        }
    }
};
